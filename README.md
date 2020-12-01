<!-- PROJECT LOGO -->
<!-- HEADER IMAGE
<br />
<p align="center">
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Best-README-Template</h3>

  <p align="center">
    An awesome README template to jumpstart your projects!
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Report Bug</a>
    ·
    <a href="https://github.com/othneildrew/Best-README-Template/issues">Request Feature</a>
  </p>
</p>
-->


<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://covid.aaronrenner.com)

This application has been created as an examples of creating connected software to inform people of the threat of the SARS-COV-2 virus across the United States. The basis and guidelines for this project application are provided from our Senior Capstone Project at [Shepherd University, Shepherdstown, WV 25443](https://goo.gl/maps/e3RNCSLP5NYajBwd7). We opted to use a Web Application using the frameworks provided by the Microsoft Dotnet core, this called a [Blazor Web Application](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor).

### Built With
* [COVID Tracking Project](https://covidtracking.com/data/api)
* [Microsoft Visual Studio CE](https://visualstudio.microsoft.com/vs/community/)
* [Dotnet Core](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Blazor Web Application](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [Docker](https://www.docker.com/)



<!-- GETTING STARTED -->
## Getting Started

This is an example of how you may give instructions on setting up your project locally. To get a local copy up and running follow these simple example steps.

### Prerequisites

Your machine will require dotnot resources to execute our application, make sure you have at least version 3. If you need to to install these resources check [Dotnet Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
```sh
dotnet --version
```

### Installation
1. Clone the repo
```sh
git clone https://github.com/Aman7123/Capstone-Portfolio-Binder.git
```
2. Frome the home directory, goto the project
```sh
cd COVIDBlazorApp/
```
3. If you have Dotnet installed you should be able to restore the project assets
```sh
dotnet restore
```
3. You can run this project on your local machine
```sh
dotnet run BlazorApp1.csproj
```
4. Navigate to your browser and access [localhost:5000](http://localhost:5000)

### Using Docker

If you are familiar with using Docker to run your project and it is installed on your machine I recommend using the build and run commands below.

1. From the root Github repo folder run
```sh
dotnet build --tag covid:1.0 .
```
2. After your image is created you can execute the webserver on your local machine by running
```sh
docker run --detach --p 5000:5000 --name covid covid:1.0
```
4. Navigate to your browser and access [localhost:5000](http://localhost:5000)


<!-- COVID Tracking Project -->
## API Resources

To build our Website we required obtaining data related to the Coronavirus Pandemic by utilizing [The COVID Tracking Project API](https://covidtracking.com/data/api), this API collects Coronavirus data from local state governments in the United States and reviews all the data to ensure it is valid.

* For the Coronavirus statistics for the whole United States today use
```http
GET https://api.covidtracking.com/v1/us/current.json
```
```json
{
    "date": int,
    "states": int,
    "positive": int,
    "negative": int,
    "pending": int,
    "hospitalizedCurrently": int,
    "hospitalizedCumulative": int,
    "inIcuCurrently": int,
    "inIcuCumulative": int,
    "onVentilatorCurrently": int,
    "onVentilatorCumulative": int,
    "recovered": int,
    "death": int,
    "totalTestResults": int,
    "deathIncrease": int,
    "hospitalizedIncrease": int,
    "negativeIncrease": int,
    "positiveIncrease": int,
    "totalTestResultsIncrease": int,
    "hash": string
}
```



<!-- CONTACT -->
## Contact

* Aaron Renner - [Github Profile](https://github.com/Aman7123/)
* Daniel Carson - [Github Profile](https://github.com/doit4dan/)

Project Link: [https://github.com/Aman7123/Capstone-Portfolio-Binder](https://github.com/Aman7123/Capstone-Portfolio-Binder)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements
* [Dotnet Blazor App getting started](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro)
* [Visual Studio Community Edition 2019 getting started](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019)
* [Docker getting started](https://docs.docker.com/get-started/)
* [Shepherd University Department of Computer, Science and Mathematics](https://www.shepherd.edu/cme)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
<!-- EXTRA RESOURCES FOR EXAMPLE
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/othneildrew/Best-README-Template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/othneildrew/Best-README-Template/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/othneildrew/Best-README-Template/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/othneildrew/Best-README-Template/issues
[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/othneildrew/Best-README-Template/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
-->
 [product-screenshot]: images/App_US_Data.png