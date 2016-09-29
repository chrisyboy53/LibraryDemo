#!/bin/bash

docker exec -i librarydemo_mysqlserver_1 mysql -ppassword -u root < ./Database/MySQL/Schema.sql
