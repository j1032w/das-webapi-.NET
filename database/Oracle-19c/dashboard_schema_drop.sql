-- NAME
--   dashboard_uninstall.sql
--
-- DESCRIPTON
--   This script removes the Dashboard schema.
--   Run as privileged user with rights to create another user (SYSTEM, ADMIN, etc.)
--
--
-- SUPPORTED with DB VERSIONS
--   19c and higher


SET SERVEROUT ON SIZE UNLIMITED;


DECLARE
    v_tablespace  VARCHAR2(30) := 'USERS';
    v_username    VARCHAR2(30) := 'DASHBOARD';
    v_tbs_exists  NUMBER       := 0;
    v_user_exists all_users.USERNAME%TYPE;

    PRAGMA AUTONOMOUS_TRANSACTION;
BEGIN
    SELECT MAX(username)
    INTO v_user_exists
    FROM all_users
    WHERE username = v_username;

    IF v_user_exists IS NULL THEN
        dbms_output.put_line('Schema "' || v_username || '" does not exist');
        RETURN;
    END IF;

    EXECUTE IMMEDIATE 'DROP USER ' || v_username || ' CASCADE';

    dbms_output.put_line('Schema "' || v_username || '" dropped successfully');
    COMMIT;


END ;
