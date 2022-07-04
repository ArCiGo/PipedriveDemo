# Pipedrive Demo assessment

A technical assessment for the **Software Engineer in Test** position.

## The project 💻

The following project was made using *C#*, *NUnit*, *Selenium* and *Extent Reports*. Review [here]() the assessment proposed.
Review the overall test plan [here]() and [here]() the test plan for the automation framework. Bug report can also found [here]()

## Tools ⚙️

* *Visual Studio Code for Mac (v17.0.5 (build 6))*.
* *C# (.NET Core 6.0.301, C# v10.0)*.
* *NUnit v3.13.3*.
* *NUnit3TestAdapter v4.2.1*.
* *Selenium.Support v4.3.0*.
* *Selenium.WebDriver v4.3.0*.
* *DotNetSeleniumExtras.WaitHelpers v3.11.0*.
* *Selenium WebDriver GeckoDriver v0.31.0.1*
* *ExtentReports v4.1.0*.

## Project structure 🗂️

```xml
|---- PipedriveDemo
    |---- Tests
        |---- Data
        |---- UI
            |---- AutomationResources
        |---- Utilities
    |---- UI
        |---- PageObjectModel
            |---- Components
                |---- DealsDashboard
                |---- DealsItem
                |---- Home
                |---- Login
            |---- Pages
            |---- Utilities
```

## Setup 🛠️

I developed the code using a Mac, but it should work on a PC.

> .NET Core 3.1, or higher, is needed to run the project.

The following steps can be executed using a terminal (I use [hyper](https://hyper.is/)).

1. Clone the repo.-

```shell
git clone https://github.com/ArCiGo/PipedriveDemo
```

2. Install the packages
```shell
dotnet build
```

## Run the tests

```shell
# Run all tests
dotnet test
```

```shell
# Running the tests by category

# UI tests
dotnet test --filter TestCategory=UI
```

When you execute the tests, new folders are generated at the workspace root (*UIReports*). 
Inside of these folders, you are going to see the index.html reports (you can open them using your favorite browser).

![UI Report Sample](./APIReport.png)
