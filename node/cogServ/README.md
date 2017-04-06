# Cognitive Services Demo - Node.js

## Step 0 - Prerequisites
If you didn't already get an Emotion API key, go back to the [main README](https://github.com/jcocchi/CognitiveServicesDemo) and follow the instructions to get an API key.

For this workshop you will need to have [Node.js](https://nodejs.org/en/download/) installed as well as any text editor- my favorite is [Visual Studio Code](https://code.visualstudio.com/download).

Fork, clone, or download this repository. From the command line, navigate to the `node/cogServ/` directory and enter `npm install`. To see the starting point for our project, run it by entering `set DEBUG=cogServ:* & npm start` if you are on a Windows machine and entering `DEBUG=cogServ:* npm start` if you are on a MacOS or Linux machine. The navigate to `http://localhost:3000/` in your browser.

> Note: From here on, all file paths are relative to `node/cogServ/`

## Step 1 - Make the API call
1. Paste your Emotion API key from step 0 inside the quotes of line 6 in `controllers/results.js` to look like this `var EMOTION_KEY = '1234'` where 1234 is your key
2. Uncomment `callAPI(url)` on line 14 of `controllers/results.js`
3. Copy the contents of `codeSnippets/callAPI.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
4. Put a breakpoint on line 16 `var results = response` and run the project
5. Navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

When the breakpoint is hit, you should see the `scores` object as well as the `faceRectangle` object returned from the API call. Press continue and wait for the results page to load. We won't see our results yet- we will only see the value of the link we passed in.

## Step 2 - Parse Results to find the top emotion
1. Uncomment `var topEmotion = parseResponse(results)` on line 19 of `controllers/results.js`
2. Copy the contents of `codeSnippets/parseResponse.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
3. Put a breakpoint on line 19 which we just uncommented and run the project
4. Navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

When the breakpoint is hit, you should see the top emotion from the photo. Press continue and wait for the results page to load. We still won't see our results yet- we will only see the value of the link we passed in.

## Step 3 - Display the results
1. Uncomment `var suggestion = makeSuggestion(topEmotion)` on line 22 of `controllers/results.js`
2. Copy the contents of `codeSnippets/makeSuggestion.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
3. Change `description: 'You entered: ' + url` on line 27 to `description: suggestion.description,`
4. Add `photo: suggestion.photo` on line 28 before the `})`
5. Run the project and navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

Now our site is complete. When you enter the URL of a photo you should see an image of someone from The Office as well as a description based on the top emotion in the photo. Try it with different photos to see what you get!

## Step 4 - Customize your site
Feel free to customize your site however you want! Change the theme, modify the suggestion to be based off of the lowest emotion score, or add another API call to make your site even smarter.

> Note: All static files are stored in the `public` folder. To add new images put them in the `public/images/` folder.
