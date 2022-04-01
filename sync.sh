#!/usr/bin/bash
while [ true ]
do
    git add .
    git commit -m "Add changes and commit"
    git push
    echo "Sync has finished!"
    echo "Enter to sync and Control + C to quit"
    read
done