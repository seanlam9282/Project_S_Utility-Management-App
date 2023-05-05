## About
This project is creating an application for utility management. Skill sets included C# and .NET Multi-platform App UI, MAUI.

## Database Preparation
Please use below SQL command to create database and table before running the app. This database will be connected to the app.
```
CREATE DATABASE UtilityManagementDB;

USE UtilityManagementDB;

CREATE TABLE AppartmentUnits(
	 unitNum INT,
	 fName VARCHAR(15) NOT NULL,
	 lName VARCHAR(15) NOT NULL,
	 beganDate DATE,
	 deposit DOUBLE NOT NULL,
	 phone VARCHAR(10),
	 rent DOUBLE NOT NULL,
	 waterLaundry DOUBLE NOT NULL,
         last_power INT,
	 new_power INT NOT NULL,	
	 CONSTRAINT phone_CK CHECK(phone IS NULL OR phone REGEXP '[0-9]{10}$'),
	 CONSTRAINT tenant_pk PRIMARY KEY (unitNum)
);

INSERT INTO AppartmentUnits VALUES (101, 'Useless', 'Aqua', "2019-03-18", 700.00, '5773662444', 2500.00, 60.00, 0, 122);
INSERT INTO AppartmentUnits VALUES (102, 'Asuna', 'Yuuki', "2021-09-09", 1200, '1234566789', 1900, 55, 0, 115);
INSERT INTO AppartmentUnits VALUES (103, 'Hitori', 'Gotoh', "2017-01-01", 69, '6969696969', 2000, 69, 0, 125);
INSERT INTO AppartmentUnits VALUES (104, 'Purple', 'Heart', "2022-09-21", 420, '7865674567', 2420, 45, 0, 138);
INSERT INTO AppartmentUnits VALUES (105, 'Yui', 'Hirasawa', "2023-02-10", 20, '9119119111', 2301, 80, 0, 95);
INSERT INTO AppartmentUnits VALUES (106, 'Ashen', 'Witch', "2020-11-08", 2000, '9999999999', 1800, 51, 0, 104);
INSERT INTO AppartmentUnits VALUES (107, 'Reimu', 'Hakurei', "2020-10-12", 900, '6452364758', 1869, 49, 0, 108);
INSERT INTO appartmentunits VALUES (108, 'Marisa', 'Kirisame', "2019-01-13", 750, '7382331234', 1999, 72, 0, 97);
```
