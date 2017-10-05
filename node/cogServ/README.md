# Cognitive Services Demo - Node.js

## Step 0 - Prerequisites
If you didn't already get an Emotion API key, go back to the [main README](https://github.com/jcocchi/CognitiveServicesDemo) and follow the instructions to get an API key.

For this workshop you will need to have [Node.js](https://nodejs.org/en/download/) installed as well as any text editor- my favorite is [Visual Studio Code](https://code.visualstudio.com/download).

Fork, clone, or download this repository. From the command line, navigate to the `[YOUR INSTALL LOCATION]/node/cogServ/` directory and enter `npm install`. To see the starting point for our project, run it by entering `set DEBUG=cogServ:* & npm start` if you are on a Windows machine and entering `DEBUG=cogServ:* npm start` if you are on a MacOS or Linux machine. The navigate to `http://localhost:3000/` in your browser.

> Note: From here on, all file paths are relative to `[YOUR INSTALL LOCATION]/CognitiveServicesDemo/node/cogServ/`

## Step 1 - Load environment variables

## Step 2 - Make the API call
1. Uncomment `callAPI(url)` on line 11 of `controllers/results.js`
2. Copy the contents of `codeSnippets/callAPI.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
3. Put a breakpoint on line 13 `var results = response` and run the project
4. Navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

When the breakpoint is hit, you should see the `Predictions` array in the object returned from the API call with values for each of the three houses we trained in our model. Press continue in your debugger and wait for the results page to load. We won't see our results yet- we will only see the value of the link we passed in.

## Step 3 - Parse results to find the top emotion
1. Uncomment `const top = parseResponse(results.Predictions)` on line 16 of `controllers/results.js`
2. Copy the contents of `codeSnippets/parseResponse.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
3. Put a breakpoint on line 16 which we just uncommented and run the project
4. Navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

When the breakpoint is hit, you should see the top tag our model predicted based on the photo. Press continue in your debugger and wait for the results page to load. We still won't see our results yet- we will only see the value of the link we passed in.

## Step 4 - Display the results
1. Uncomment `const data = getTagData(top)` on line 19 of `controllers/results.js`
2. Copy the contents of `codeSnippets/getTagData.txt` and paste them in `controllers/results.js` under the "Helper Functions Here" comment at the end of the file
3. Modify the object in the second parameter of `res.render()` on line 22 to look like
```javascript
    res.render('results', {
      title: 'Results',
      description: data.description,
      probability: data.probability,
      photo: data.photo
    })
```
5. Run the project without any breakpoints and navigate to `http://localhost:3000/`, enter the URL of a photo and hit enter

Now our site is complete! When you enter the URL of a photo you should see either the Lannister, Stark, or Targaryen sigil along with the probablity that our model got the house correct. Try it with different photos to see what you get!

> Note: One of the three houses will be returned with every photo, even if the photo has nothing to do with any of the sigils, but the probablility that it is correct will be small. 

## Step 5 - Customize your site
Feel free to customize your site however you want! Continue tweaking your model and the images that you used to train it to try to get an even better accuracy. 

> Note: All static files are stored in the `public` folder. To change the images displayed for each result put them in the `public/images/` folder and be sure to change the filename being returned by `getTagData()`.
