DECLARE
    v_username VARCHAR2(30) := 'DASHBOARD';
    PRAGMA AUTONOMOUS_TRANSACTION;

BEGIN
    EXECUTE IMMEDIATE 'ALTER SESSION SET CURRENT_SCHEMA=' || v_username;


   EXECUTE IMMEDIATE '
   CREATE OR REPLACE PROCEDURE print_cursor(
       p_refcursor IN OUT SYS_REFCURSOR, v_maxrows IN NUMBER DEFAULT 10)
   AS
       v_desc     dbms_sql.DESC_TAB;
       v_cols     BINARY_INTEGER;
       v_cursor   BINARY_INTEGER;
       v_varchar2 VARCHAR2(4000);
       v_number   NUMBER;
       v_date     DATE;
       v_data     VARCHAR2(32767);
       v_currow   NUMBER;
   BEGIN
       /* Convert refcursor "parameter" to DBMS_SQL cursor... */
       v_cursor := dbms_sql.to_cursor_number(p_refcursor);
       /* Describe the cursor... */
       dbms_sql.describe_columns(v_cursor, v_cols, v_desc);
       /* Define columns to be fetched. We''re only using V2, NUM, DATE for example... */
       FOR i IN 1 .. v_cols
       LOOP
           IF v_desc(i).col_type = 2 THEN
               dbms_sql.define_column(v_cursor, i, v_number);
           ELSIF v_desc(i).col_type = 12 THEN
               dbms_sql.define_column(v_cursor, i, v_date);
           ELSE
               dbms_sql.define_column(v_cursor, i, v_varchar2, 4000);
           END IF;
       END LOOP;
       /* Now output the data, starting with header... */
       dbms_output.new_line;
       FOR i IN 1 .. v_cols
       LOOP
           v_data := v_data ||
                     CASE v_desc(i).col_type
                         WHEN 2
                             THEN
                             LPAD(v_desc(i).col_name, v_desc(i).col_max_len + 1)
                         WHEN 12
                             THEN
                             RPAD(v_desc(i).col_name, 22)
                         ELSE
                             RPAD(v_desc(i).col_name, v_desc(i).col_max_len + 1)
                     END || '' '';
       END LOOP;
       dbms_output.put_line(v_data);
       v_data := NULL;
       FOR i IN 1 .. v_cols
       LOOP
           v_data := v_data ||
                     CASE v_desc(i).col_type
                         WHEN 2
                             THEN
                             LPAD(''-'', v_desc(i).col_max_len + 1, ''-'')
                         WHEN 12
                             THEN
                             RPAD(''-'', 22, ''-'')
                         ELSE
                             RPAD(''-'', v_desc(i).col_max_len + 1, ''-'')
                     END || '' '';
       END LOOP;
       dbms_output.put_line(v_data);
       /* Fetch all data... */
       v_currow := v_maxrows;
       WHILE dbms_sql.fetch_rows(v_cursor) > 0
       LOOP
           v_data := NULL;
           FOR i IN 1 .. v_cols
           LOOP
               IF v_desc(i).col_type = 2 THEN
                   dbms_sql.column_value(v_cursor, i, v_number);
                   v_data := v_data || LPAD(v_number, v_desc(i).col_max_len + 1) || '' '';
               ELSIF v_desc(i).col_type = 12 THEN
                   dbms_sql.column_value(v_cursor, i, v_date);
                   v_data := v_data || RPAD(v_date, 22) || '' '';
               ELSE
                   dbms_sql.column_value(v_cursor, i, v_varchar2);
                   v_data := v_data || RPAD(v_varchar2, v_desc(i).col_max_len + 1) || '' '';
               END IF;
           END LOOP;
           dbms_output.put_line(v_data);
           IF v_maxrows <> 0 THEN
               v_currow := v_currow - 1;
               EXIT WHEN 0 = v_currow;
           END IF;
       END LOOP;
       dbms_sql.close_cursor(v_cursor);
   END;';



    COMMIT;

    dbms_output.put_line('Utilities procedures created');

EXCEPTION
    WHEN OTHERS THEN
        dbms_output.put_line(dbms_utility.format_error_stack);
        dbms_output.put_line(dbms_utility.format_error_backtrace);
        ROLLBACK;

END;