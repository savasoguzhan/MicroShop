<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Project Title</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f9;
            color: #333;
            margin: 0;
            padding: 0;
        }
        header {
            background-color: #343a40;
            color: #fff;
            padding: 20px;
            text-align: center;
        }
        h1 {
            font-size: 2.5em;
        }
        section {
            padding: 20px;
        }
        pre {
            background-color: #272727;
            color: #f8f8f2;
            padding: 10px;
            border-radius: 5px;
            font-size: 1.1em;
            overflow-x: auto;
        }
        h2 {
            color: #007bff;
        }
        ul {
            list-style-type: none;
            padding-left: 0;
        }
        li {
            margin: 10px 0;
        }
        footer {
            background-color: #343a40;
            color: #fff;
            padding: 10px;
            text-align: center;
            position: fixed;
            width: 100%;
            bottom: 0;
        }
    </style>
</head>
<body>

<header>
    <h1>Microservice Project - .NET 6</h1>
    <p>This project is an example of a microservice architecture developed using .NET 6.</p>
</header>

<section>
    <h2>About the Project</h2>
    <p>This project demonstrates the usage of microservice architecture built with .NET 6. It showcases how multiple services can operate independently and communicate with each other via APIs. Each microservice has its own database and can be updated independently of others.</p>

    <h3>Features</h3>
    <ul>
        <li>Inter-service communication via API</li>
        <li>Each microservice has its own database</li>
        <li>Containerized (with Docker support)</li>
        <li>RESTful APIs for inter-service data exchange</li>
        <li>Event-driven architecture (using message queues like RabbitMQ or Kafka)</li>
    </ul>
</section>

<section>
    <h2>Getting Started</h2>
    <p>To get started with this project, follow the steps below.</p>

    <h3>Requirements</h3>
    <ul>
        <li><a href="https://dotnet.microsoft.com/download/dotnet/6.0" target="_blank">.NET 6 SDK</a></li>
        <li>Docker (optional, for containerization)</li>
        <li>Visual Studio or any IDE of your choice</li>
    </ul>

    <h3>Project Setup</h3>
    <pre>
git clone https://github.com/username/projectname.git
cd projectname
dotnet restore
    </pre>

    <h3>Running the Project</h3>
    <p>To run the project locally, use the following command:</p>
    <pre>
dotnet run --project MicroserviceExample/MicroserviceExample.csproj
    </pre>

    <h3>Running with Docker</h3>
    <p>If you'd like to run the project using Docker, follow these steps:</p>
    <pre>
docker-compose up --build
    </pre>
</section>

<section>
    <h2>API Endpoints</h2>
    <p>The project includes several RESTful API endpoints for service communication:</p>
    <ul>
        <li><strong>GET</strong> /api/products - List all products</li>
        <li><strong>GET</strong> /api/products/{id} - Get a specific product by ID</li>
        <li><strong>POST</strong> /api/products - Add a new product</li>
        <li><strong>PUT</strong> /api/products/{id} - Update an existing product</li>
        <li><strong>DELETE</strong> /api/products/{id} - Delete a product</li>
    </ul>
</section>

<section>
    <h2>Contributing</h2>
    <p>If you'd like to contribute to the project, please follow these steps:</p>
    <ul>
        <li>Fork the repository and create your own copy.</li>
        <li>Make changes and commit them to your fork.</li>
        <li>Submit a pull request.</li>
    </ul>
</section>

<footer>
    <p>&copy; 2024  - All rights reserved.</p>
</footer>

</body>
</html>
