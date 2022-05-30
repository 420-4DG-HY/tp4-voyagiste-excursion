# À propos de l'API

Ce sous-projet est l'interface de l'application vers le monde extérieur. L'API 
est exposé sous forme de service web respectant le standard OpenAPI. Pour des 
raisons historiques, on appelle encore ce standard sous le nom de Swagger.

Ce standard permet d'obtenir le "mode d'emploi" de l'API et ses DTO sous la forme 
de fichier JSON. À partir de ce fichier on peut utiliser des compléments de 
service activés pendant le développement (debug) pour afficher et tester le 
service ReST à travers des pages web générées automatiquement. On peut donc utiliser
ces interfaces pour explorer divers scénarios de tests manuels.

## Utilisation d'un gateway et autre intermédiaires

Il est rare qu'on expose directement les microservices. En plus des dispositifs de 
sécurité, de contrôle d'accès et d'équilibrage de charge, on voit généralement un 
service de gateway permettant de consolider l'offre de service publique de tous les 
microservices du système. C'est comme une façade, mais pour consolider les API au 
lieu des objets. 

## Configuration des ports des microservices

Dans le cadre de ce TP, l'architecture est simplifie pour se passer de gateway. 
On peut accéder directement à chacun des services, soit en adressant le conteneur 
avec son port de service normal (80/443), soit via l'hôte avec les ports redirigés
par la configuration de docker-compose (voir le fichier .yml) C'est pratique pour nos 
tests, mais on ne fait jamais ça en production car ça fait beaucoup de ports à 
protéger. D'où l'intérêt du gateway.

## Pour utiliser l'API dans un autre projet (Client de l'API)

Quand le service roule (disponible via https) on peut y accéder via son inerface Swagger.
Dans le haut de la page Swagger il y a un lien vers le fichier .json qui décrit le service. 
On peut aussi obtenir ce fichier à l'aide de Visual Studio à l'aide du menu (clic-droit 
sur le projet)[Ajouter] > [Référence de service]. En fournissant l'URL de l'API, Visual 
Studio ajoutera le fichier swagger.json dans le dossier OpenAPIs du projet. Ce fichier peut 
être renommé pour distinguer tous les APIs que l'ont veut utiliser dans notre projet.

À partir de ce fichier .json, on peut voir le code de proxy généré est en classe si on ouvre 
le petit [+] devant le fichier.

