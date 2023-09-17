DECLARE
    v_username VARCHAR2(30) := 'DASHBOARD';
    PRAGMA AUTONOMOUS_TRANSACTION;

BEGIN
    EXECUTE IMMEDIATE 'ALTER SESSION SET CURRENT_SCHEMA=' || v_username;


    -- Create table: residential_properties
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE TABLE "residential_properties"
    (
        "id"                           NUMBER GENERATED AS IDENTITY,
        "building_amenity"             VARCHAR2(255),
        "building_bathroom_total"      NUMBER,
        "building_bedroom"             NUMBER,
        "building_size_interior"       FLOAT,
        "building_stories_total"       NUMBER,
        "building_type"                VARCHAR2(255),
        "distance"                     VARCHAR2(255),
        "land_landscape_feature"       VARCHAR2(255),
        "land_size_total"              VARCHAR2(255),
        "listing_boundary"             VARCHAR2(255),
        "mls_number"                   VARCHAR2(255),
        "postal_code"                  VARCHAR2(255),
        "price_unformatted_value"      FLOAT,
        "property_amenity_near_by"     VARCHAR2(255),
        "property_ownership_type"      VARCHAR2(255),
        "property_parking_space_total" NUMBER,
        "property_parking_type"        VARCHAR2(255),
        "property_type"                VARCHAR2(255),
        "province_name"                VARCHAR2(255),
        "public_remark"                VARCHAR2(255),
        "city"                         VARCHAR2(255),
        "listed_time"                  TIMESTAMP(6),
        "modified_time"                TIMESTAMP(6)
    )';


    EXECUTE IMMEDIATE '
    CREATE UNIQUE INDEX "residential_properties_pk"
        ON "residential_properties" ("id")';


    EXECUTE IMMEDIATE '
    CREATE TRIGGER "residential_properties_modified_time_ti"
        BEFORE INSERT OR UPDATE
        ON "residential_properties"
        FOR EACH ROW
    BEGIN
        :new."modified_time" := SYSTIMESTAMP;
    END;
    ';


    -- Create stored procedure: find_all
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE PROCEDURE "residential_properties_find_all_prc"(
        i_city IN "residential_properties"."city"%TYPE DEFAULT NULL,
        i_building_type IN "residential_properties"."building_type"%TYPE DEFAULT NULL,
        i_max_price IN "residential_properties"."price_unformatted_value"%TYPE DEFAULT NULL,
        i_min_price IN "residential_properties"."price_unformatted_value"%TYPE DEFAULT NULL,
        o_result OUT SYS_REFCURSOR)
    AS
    BEGIN
        OPEN o_result FOR
            SELECT *
            FROM "residential_properties"
            WHERE (UPPER("city") = UPPER(i_city) OR i_city IS NULL)
              AND (UPPER("building_type") = i_building_type OR i_building_type IS NULL)
              AND ("price_unformatted_value" >= i_min_price OR i_max_price IS NULL)
              AND ("price_unformatted_value" <= i_max_price OR i_max_price IS NULL);

    END;
    ';


    -- Create stored procedure: find_by_id
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE PROCEDURE "residential_properties_find_by_id_prc"(
        i_id IN "residential_properties"."id"%TYPE,
        o_result OUT "residential_properties"%ROWTYPE)
    AS
    BEGIN
        SELECT *
        INTO o_result
        FROM "residential_properties"
        WHERE "id" = i_id;
    END;
    ';

    -- Create stored procedure: insert
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE PROCEDURE "residential_properties_insert_prc"(
        i_building_amenity IN "residential_properties"."building_amenity"%TYPE,
        i_building_bathroom_total IN "residential_properties"."building_bathroom_total"%TYPE,
        i_building_bedroom IN "residential_properties"."building_bedroom"%TYPE,
        i_building_size_interior IN "residential_properties"."building_size_interior"%TYPE,
        i_building_stories_total IN "residential_properties"."building_stories_total"%TYPE,
        i_building_type IN "residential_properties"."building_type"%TYPE,
        i_distance IN "residential_properties"."distance"%TYPE,
        i_land_landscape_feature IN "residential_properties"."land_landscape_feature"%TYPE,
        i_land_size_total IN "residential_properties"."land_size_total"%TYPE,
        i_listing_boundary IN "residential_properties"."listing_boundary"%TYPE,
        i_mls_number IN "residential_properties"."mls_number"%TYPE,
        i_postal_code IN "residential_properties"."postal_code"%TYPE,
        i_price_unformatted_value IN "residential_properties"."price_unformatted_value"%TYPE,
        i_property_amenity_near_by IN "residential_properties"."property_amenity_near_by"%TYPE,
        i_property_ownership_type IN "residential_properties"."property_ownership_type"%TYPE,
        i_property_parking_space_total IN "residential_properties"."property_parking_space_total"%TYPE,
        i_property_parking_type IN "residential_properties"."property_parking_type"%TYPE,
        i_property_type IN "residential_properties"."property_type"%TYPE,
        i_province_name IN "residential_properties"."province_name"%TYPE,
        i_public_remark IN "residential_properties"."public_remark"%TYPE,
        i_city IN "residential_properties"."city"%TYPE,
        i_listed_time IN "residential_properties"."listed_time"%TYPE,
        o_id OUT "residential_properties"."id"%TYPE)
    AS
        PRAGMA AUTONOMOUS_TRANSACTION;
    BEGIN

        INSERT INTO "residential_properties"("building_amenity",
                                             "building_bathroom_total",
                                             "building_bedroom",
                                             "building_size_interior",
                                             "building_stories_total",
                                             "building_type",
                                             "distance",
                                             "land_landscape_feature",
                                             "land_size_total",
                                             "listing_boundary",
                                             "mls_number",
                                             "postal_code",
                                             "price_unformatted_value",
                                             "property_amenity_near_by",
                                             "property_ownership_type",
                                             "property_parking_space_total",
                                             "property_parking_type",
                                             "property_type",
                                             "province_name",
                                             "public_remark",
                                             "city",
                                             "listed_time")
        VALUES (i_building_amenity,
                i_building_bathroom_total,
                i_building_bedroom,
                i_building_size_interior,
                i_building_stories_total,
                i_building_type,
                i_distance,
                i_land_landscape_feature,
                i_land_size_total,
                i_listing_boundary,
                i_mls_number,
                i_postal_code,
                i_price_unformatted_value,
                i_property_amenity_near_by,
                i_property_ownership_type,
                i_property_parking_space_total,
                i_property_parking_type,
                i_property_type,
                i_province_name,
                i_public_remark,
                i_city,
                i_listed_time);
        COMMIT;
    END;';

    -- Create stored procedure: update
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE PROCEDURE "residential_properties_update_prc"(
        i_id IN "residential_properties"."id"%TYPE,
        i_building_amenity IN "residential_properties"."building_amenity"%TYPE,
        i_building_bathroom_total IN "residential_properties"."building_bathroom_total"%TYPE,
        i_building_bedroom IN "residential_properties"."building_bedroom"%TYPE,
        i_building_size_interior IN "residential_properties"."building_size_interior"%TYPE,
        i_building_stories_total IN "residential_properties"."building_stories_total"%TYPE,
        i_building_type IN "residential_properties"."building_type"%TYPE,
        i_distance IN "residential_properties"."distance"%TYPE,
        i_land_landscape_feature IN "residential_properties"."land_landscape_feature"%TYPE,
        i_land_size_total IN "residential_properties"."land_size_total"%TYPE,
        i_listing_boundary IN "residential_properties"."listing_boundary"%TYPE,
        i_mls_number IN "residential_properties"."mls_number"%TYPE,
        i_postal_code IN "residential_properties"."postal_code"%TYPE,
        i_price_unformatted_value IN "residential_properties"."price_unformatted_value"%TYPE,
        i_property_amenity_near_by IN "residential_properties"."property_amenity_near_by"%TYPE,
        i_property_ownership_type IN "residential_properties"."property_ownership_type"%TYPE,
        i_property_parking_space_total IN "residential_properties"."property_parking_space_total"%TYPE,
        i_property_parking_type IN "residential_properties"."property_parking_type"%TYPE,
        i_property_type IN "residential_properties"."property_type"%TYPE,
        i_province_name IN "residential_properties"."province_name"%TYPE,
        i_public_remark IN "residential_properties"."public_remark"%TYPE,
        i_city IN "residential_properties"."city"%TYPE,
        i_listed_time IN "residential_properties"."listed_time"%TYPE)
    AS
        PRAGMA AUTONOMOUS_TRANSACTION;
    BEGIN
        UPDATE "residential_properties"
        SET "building_amenity"             = i_building_amenity,
            "building_bathroom_total"      = i_building_bathroom_total,
            "building_bedroom"             = i_building_bedroom,
            "building_size_interior"       = i_building_size_interior,
            "building_stories_total"       = i_building_stories_total,
            "building_type"                = i_building_type,
            "distance"                     = i_distance,
            "land_landscape_feature"       = i_land_landscape_feature,
            "land_size_total"              = i_land_size_total,
            "listing_boundary"             = i_listing_boundary,
            "mls_number"                   = i_mls_number,
            "postal_code"                  = i_postal_code,
            "price_unformatted_value"      = i_price_unformatted_value,
            "property_amenity_near_by"     = i_property_amenity_near_by,
            "property_ownership_type"      = i_property_ownership_type,
            "property_parking_space_total" = i_property_parking_space_total,
            "property_parking_type"        = i_property_parking_type,
            "property_type"                = i_property_type,
            "province_name"                = i_province_name,
            "public_remark"                = i_public_remark,
            "city"                         = i_city,
            "listed_time"                  = i_listed_time
        WHERE "id" = i_id;
    END;';


    -- Create stored procedure: delete
    --------------------------------------------------------------------------
    EXECUTE IMMEDIATE '
    CREATE OR REPLACE PROCEDURE "residential_properties_delete_prc"(
        i_id IN "residential_properties"."id"%TYPE)
    AS
        PRAGMA AUTONOMOUS_TRANSACTION;
    BEGIN
        DELETE
        FROM "residential_properties"
        WHERE "id" = i_id;
    END;';



    COMMIT;

    dbms_output.put_line('Table and stored procedures created');

EXCEPTION
    WHEN OTHERS THEN
        dbms_output.put_line(dbms_utility.format_error_stack);
        dbms_output.put_line(dbms_utility.format_error_backtrace);
        ROLLBACK;

END;