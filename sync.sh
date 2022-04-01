#!/usr/bin/bash
while [ true ]
do
    git add .
    git commit -m "Add changes and commit"
    git push
    read
done