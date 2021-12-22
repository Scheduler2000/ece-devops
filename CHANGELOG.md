# Changelog

All notable changes to this project will be documented in this file. See [standard-version](https://github.com/conventional-changelog/standard-version) for commit guidelines.

### [1.1.1](https://github.com/Scheduler2000/ece-devops/compare/v1.1.0...v1.1.1) (2021-12-22)


### Bug Fixes

* **infra:** fix kubernetes configuration files ([13e12e8](https://github.com/Scheduler2000/ece-devops/commit/13e12e8a3943d6257070f4841f7d265c07343e52))

## 1.1.0 (2021-12-22)


### Features

* **backend:** add DB_URL env variable for mysql connection string (usefull for k8s) ([d67a165](https://github.com/Scheduler2000/ece-devops/commit/d67a165c55c9a65838e6dc382d213a6fe2093c6a))
* **backend:** add GET Operations for UserAPI ([6fda9fa](https://github.com/Scheduler2000/ece-devops/commit/6fda9fa39f61b357634909ee0c462d2c6b64a26c))
* **backend:** add health endpoint for k8s probes ([76a516d](https://github.com/Scheduler2000/ece-devops/commit/76a516dd132cdb2ff292787568b1bf0ec039a0fc))
* **backend:** add open api description for the swagger ([273c982](https://github.com/Scheduler2000/ece-devops/commit/273c982ac306839b52ee94a7e6394cd7ab3d6989))
* **backend:** add Read, Update, Delete operations for user api ([5c7e741](https://github.com/Scheduler2000/ece-devops/commit/5c7e7419e193f75073ef2e0deda9e1850541cb61))
* **backend:** add user api CRUD tests ([4e9aacc](https://github.com/Scheduler2000/ece-devops/commit/4e9aacc4721661aca541a6dd8701d75bdfebfe17))
* **backend:** create empty micro service used for an User API ([06e3935](https://github.com/Scheduler2000/ece-devops/commit/06e39359ace44b3c988c435217307f3cd5700ca1))
* **backend:** Implement CRUD operation for an user with MYSQL as a SGBDR and Dapper as a micro-orm ([4a776d4](https://github.com/Scheduler2000/ece-devops/commit/4a776d4813cb867329e661b74eec8dd10b73b72a))
* **backend:** setup Serilog for logging into kibana ([3acf724](https://github.com/Scheduler2000/ece-devops/commit/3acf7240e1656af1d2614f6ce73c2ca6b889396f))
* **git:** setup git hook with husky and commitlint for ensuring commit message format ([735dadb](https://github.com/Scheduler2000/ece-devops/commit/735dadb92d40d5f2beca285e748c14daa538c837))
* **infra:** configurate mysql database for docker-compose ([1e003c1](https://github.com/Scheduler2000/ece-devops/commit/1e003c1622c64016c09c578e854903e9744b53ec))
* **infra:** configure dockerignore file for backend api ([bddea48](https://github.com/Scheduler2000/ece-devops/commit/bddea489a5be7bfbe6d04df978392fb4933b27c7))
* **infra:** configure k8s readiness, liveness, startup for backend api ([19d1de5](https://github.com/Scheduler2000/ece-devops/commit/19d1de5d2ecb6deee8abecd1eb25cfca488fdef4))
* **infra:** configure kubernetes deployments, services, configmaps and secrets for a local cluster ([05f028f](https://github.com/Scheduler2000/ece-devops/commit/05f028f319ab57a84e48c52c92bc1fdea1740167))
* **infra:** create backend dockerfile and configure it in docker-compose ([3580c80](https://github.com/Scheduler2000/ece-devops/commit/3580c80a0b770a49ec248edd868bae352e729687))
* **infra:** save docker volumes ([d53e8a9](https://github.com/Scheduler2000/ece-devops/commit/d53e8a9b6d14a81c2494e32932eb4f90ce2eff94))
* **infra:** setup kibana and elasticsearch container ([c48fa12](https://github.com/Scheduler2000/ece-devops/commit/c48fa12fba964de6bffc7f303746c5aafc5abd85))
* **infra:** use docker image pushed by github action instead of using local image ([e42212a](https://github.com/Scheduler2000/ece-devops/commit/e42212a22b71352246e9392b8b8a76304090ad99))
* **project:** add standard-version to project in order to generate changelogs dynamically ([d9ee8d0](https://github.com/Scheduler2000/ece-devops/commit/d9ee8d0f57b56213c79dde3cec93d3330f64baee))
* **project:** init github repository ([ba27127](https://github.com/Scheduler2000/ece-devops/commit/ba2712736dd8e0ee6f70ad7c693b4bc4d1ed41ad))


### Bug Fixes

* **infra:** fix docker compose file ([c34e01d](https://github.com/Scheduler2000/ece-devops/commit/c34e01d486f9d96464b1823b3922948d6b443de0))
* **infra:** fix sql database column name for mapping with dapper orm ([6dab5f4](https://github.com/Scheduler2000/ece-devops/commit/6dab5f420a3a340a10f7dced16eb491e31ddc6a7))
* **tests:** move user api tests at the good place ([b3a914d](https://github.com/Scheduler2000/ece-devops/commit/b3a914df84d9886974d5800bd0adacce3acd4648))
