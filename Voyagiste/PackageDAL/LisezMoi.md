# À propos du Proxy de l'API

Ce sous-projet n'est pas toujours nécessaire. En général on génère un proxy des API dont on a besoin à 
l'aide d'outils tels que AutoRest, NSwag, Swagger, OpenAPI et autres extensions de Visual Studio. 
On placera donc ces proxy générés à même le code de la couche DAL.

Il est cependant intéressant de fournir en librairie le code qui utilise les mêmes DTO que le service. 
On s'assure ainsi d'avoir le namespace et les DTO avec un typage plus fort qui épouse plus parfaitement 
le modèle d'origine. 

Que ce soit avec un proxy généré ou avec un proxy fourni comme celui-ci, dans une architecture 3 tiers, on veillera
à ce que les proxys soient tous utilisés via le DAL afin de pouvoir substituer facilement l'accès à toutes les données
externes lors des tests.