#!/bin/bash

npm update;
npm install;
dotnet restore;
dotnet build;
dotnet test;