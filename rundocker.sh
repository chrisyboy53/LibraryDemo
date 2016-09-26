#!/bin/bash

docker build -t libdemo_v1 .;

docker run -it -p 5000:5000 libdemo_v1;