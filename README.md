# OData Bug Reproduction

A reproduction of some sort of race condition in the OData libraries.

## Steps

1. Build the ODataBug.Web project and add it to IIS. Use http://odatabug.localtest.me/ as the URL.
2. Run the ODataBug.StressTest project, watch it fail periodically with an unexpected Bad Request.