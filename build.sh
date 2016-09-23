#!/bin/bash

npm install;
dotnet restore;
dotnet build;
dotnet test;