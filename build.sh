#!/bin/bash
set -e

npm update;
npm install;
dotnet restore;
dotnet build;
dotnet test;