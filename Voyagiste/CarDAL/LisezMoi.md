# À propos du DAL et du modèle de données

Le Data Access Layer (DAL) contient tout ce qui est nécessaire pour accéder aux données. 
Il s'agit généralement d'une couche où on retrouve tous les accès aux bases de données.
On y retrouve aussi les accès aux API externes et les base de données de cache qui gardent 
une copie des données de références entretenus par les messages entrants auquels 
l'application est abonnée.

Le DAL est donc l'endroit où on concentre toutes les données persistentes propres au domaine
du microservice (celles dont le microservice est responsable) et dans une architecture par 
événements, une copie des données externes dont on dépend. Les données mutables sont stockées
normalement dans le namespace/dossier model sous forme de classes correspondant aux tables des
bases de données via un mappage objet-relationnel (ORM).

## Ceci n'est pas un DAL de production

Afin de simplifier ce TP, aucune base de donnée réelle n'est utilisée et les dépendances 
externes sont traités par des appels directs aux services dont on dépend. L'utilisation d'une 
façade permet d'avoir interface unifié et remplaçable vers toutes ces données.  On pourra donc  
éventuellement remplacer cette couche mock par un accès réel aux données stockées en propre et 
aux données répliquées des services dont on dépend.