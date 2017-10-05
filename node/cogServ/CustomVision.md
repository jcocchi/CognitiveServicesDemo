# Custom Vision Model #

Custom Vision Service is a tool for building custom image classifiers. It makes it easy and fast to build, deploy, and improve an image classifier.

## Step 0 - Prerequisites
* A [Microsoft Account](https://signup.live.com/) is necessary in order to use the [customvision.ai](https://customvision.ai) website. Please sign up for one if you do not already have one. A Skype ID or a Xbox Live account are all considered Microsoft Accounts.
* The images that we are using for building the model are in the `VisionTrainingImages` folder above.
* Feel free to find a few test images online. You only need the URL of the image to test.

## Step 1 - Getting Started
To get started go to [https://customvision.ai](https://customvision.ai) after logging in with your Microsoft Account:
*Click `New Project` to create your first project
* Accept Terms of Service
* Add a Name and Description to the project
* For this project select `General` as the Domain and click `Create project`

## Step 2 - Adding Images
Now that we are in the main portal we are going to add the images in the `VisionTrainingImages` folder from the repository:
* Add the images from the `Lannister` folder and add the Tag `Lannister` (Make sure when you add the Tag that the L in is capitalized, because it is capitalized in the code)
* Add the images from the `Stark` folder and add the Tag `Stark` (Make sure when you add the Tag that the S in is capitalized, because it is capitalized in the code)
* Add the images from the `Targaryen` folder and add the Tag `Targaryen` (Make sure when you add the Tag that the T in is capitalized, because it is capitalized in the code)

## Step 3 - Training & Testing
We are now ready to train the model:
* Click the Green button labeled `Train` at the top of the page.
The model will train and test your images and give you a performance review for each iteration.
* You can now perform a quick test using an URL of an image

## Step 4 - Pediction URL & Key
Click the `Prediction URL` to save the URL and Prediction Key.
You are now ready to proceed to Step 1 on the README