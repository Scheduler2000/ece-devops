# Deprecation policy

This project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

Given a version number MAJOR.MINOR.PATCH, increment the:

- MAJOR version when you make incompatible API changes,
- MINOR version when you add functionality in a backwards compatible manner, and
- PATCH version when you make backwards compatible bug fixes.


## API

- Every change to the API must be tested for retro-compatibility before a release.
- If a change occurs on the API that break compatibility, we're force to create a new MAJOR release.
- The path `/api/head` will always point to the last version of the API.
- Every version of the API will stay available through `/api/v1`, `/api/v2`...


