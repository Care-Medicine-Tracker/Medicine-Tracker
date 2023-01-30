
#   Care-Medicine-Tracker
 ## Vision of the project
The vision of the project is for users to be able to track their medicines and to receive notifications to do so. Further, is it also nice if their  caretakers, family and friends can also keep track of their intake and receive notifications of this as well.

## Goal for the semester (6 months period)
For the reason that the project has a short amount of time to be worked on (6 months) with also adding new technical aspects such as:
- Microservices 
- Cloud
- Testing
- Ci/Cd
- Security

Is the vision of the project a bit less in functionality where the new goal for this timespan is to implement the following:
- Have two working microservices
- Add Unit Testing
- Integrate security testing 
- Add Continuous Integration
- Upload the project to a cloud provider (Azure Kubernetes Service)

## Tools
| Tools | Usage |
|--|--|
|[C# & .Net](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/)   | To create the microservices. |
| [React](https://reactjs.org/) | For developing the frontend. |
| [Kubernetes](https://kubernetes.io/) | To be able to deploy the project to the cloud. |
| [NGINX](https://www.nginx.com/products/nginx-ingress-controller/) | Api gateway between services. |
| [XUnit](https://xunit.net/) | Creating the Unit Tests. |
| [Azure Kubernetes Service](https://azure.microsoft.com/en-us/products/kubernetes-service/) | Uploading the project to the cloud. |
| [Azure Active Directory](https://azure.microsoft.com/en-us/products/active-directory) | Adding Single Page Authentication. |

## Repositories of the project

| Tools | Usage |
|--|--|
| [Medicine-Tracker](https://github.com/Care-Medicine-Tracker/Medicine-Tracker/tree/main/Documentation) | Documentation regarding the design, infrastructure and choices made to the project. |
| [MedicineInventory](https://github.com/Care-Medicine-Tracker/MedicineInventory) | The Medicine Inventory Service is in charge of all registered medicines to the Care web-application. |
| [UserMedicineInventory](https://github.com/Care-Medicine-Tracker/UserMedicineInventory) | The User Medicine Inventory Service is in charge of all registered medicines belonging to users to the Care web-application. |
| [CareFrontend](https://github.com/Care-Medicine-Tracker/CareFrontend) | The Care frontend has been designed to create medicines and assign them to users. |
| [Infra](https://github.com/Care-Medicine-Tracker/Infra) | Infra server for Care microservice. this repo contains how the docker images needed to run the entire application. |
| [Care.Common](https://github.com/Care-Medicine-Tracker/Care.Common) | NuGet packages used for the Care-Medicine-tracker project. |
