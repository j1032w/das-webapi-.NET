-- NAME
--   dashboard_schema.sql

-- DESCRIPTION
--   Run this script to create the Dashboard schema
--   Run as privileged user with rights to create another user (SYSTEM, ADMIN, etc.)


-- SUPPORTED with DB VERSIONS
--   This script was tested on 19c.


-- UNINSTALL INSTRUCTIONS
--   If you have installed the Dashboard schema, you can remove it
--   by running the dashboard_uninstall.sql script

----------------------------------------------------------------------------

SET SERVEROUT ON SIZE UNLIMITED;


DECLARE
    v_tablespace   VARCHAR2(30) := 'USERS';
    v_password     VARCHAR2(30) := 'password123';
    v_username     VARCHAR2(30) := 'DASHBOARD';
    v_is_overwrite VARCHAR2(1)  := 'Y';

    PRAGMA AUTONOMOUS_TRANSACTION;
BEGIN

    ------------------------------------------------------------------------
    -- Validate tablespace
    DECLARE
        v_tbs_exists NUMBER := 0;
    BEGIN
        SELECT COUNT(1)
        INTO v_tbs_exists
        FROM dba_tablespaces
        WHERE tablespace_name = v_tablespace;
        IF v_tbs_exists = 0 THEN
            RAISE_APPLICATION_ERROR(-20998,
                                    'Error: the tablespace ''' || UPPER(v_tablespace) || ''' does not exist!');
        END IF;
    END;

    ------------------------------------------------------------------------
    -- Create schema
    DECLARE
        v_user_exists all_users.USERNAME%TYPE;
    BEGIN
        SELECT MAX(username)
        INTO v_user_exists
        FROM all_users
        WHERE username = v_username;


        -- Schema already exists
        IF v_user_exists IS NOT NULL THEN
            IF v_is_overwrite = 'N' THEN
                RAISE_APPLICATION_ERROR(-20997, 'Abort: the schema already exists');
            ELSE
                dbms_output.put_line('Schema "'|| v_username || '" already exists, dropping it...');
                EXECUTE IMMEDIATE 'DROP USER ' || v_username || ' CASCADE';
            END IF;
        END IF;

        -- Create schema
        EXECUTE IMMEDIATE 'CREATE USER ' || v_username ||
                          ' IDENTIFIED BY ' || v_password ||
                          ' DEFAULT TABLESPACE ' || v_tablespace ||
                          ' QUOTA UNLIMITED ON ' || v_tablespace;


        EXECUTE IMMEDIATE 'GRANT CONNECT, RESOURCE, DBA TO ' || v_username;
    END;

    dbms_output.put_line('Schema "' || v_username || '" created');
    COMMIT;

EXCEPTION
    WHEN OTHERS THEN
        dbms_output.put_line(dbms_utility.format_error_stack);


END ;

