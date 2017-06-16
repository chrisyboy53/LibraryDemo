#!/bin/bash

docker exec -i dotnetlibrarydemo_mysqlserver_1 mysql -ppassword -u root < ./Database/MySQL/Schema.sql
