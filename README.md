# VIRIN Mock Services

## FOR DEVELOPMENT AND TESTING PURPOSES ONLY

## If you have the opportunity please fork, change, update, and add to this project as you desire


### Virin Generator

- Generates mock VIRIN (Visual Information Record Identification Number) strings based on the NITFS (National Imagery Transmission Format Standard). 

- The VIRIN standard is a unique identifier for imagery and geospatial data used by the Department of Defense (DoD) and other government agencies.

VIRIN regex pattern from SharedMediaManager.Components.Helper.cs (no date check):
- `^\d{6,6}-[AFMNGDOHSXZ]{1,1}-[A-Za-z\d]{5,5}-\d{3,3}\d?[A-Za-z]?(-[A-Za-z]{2,2})?$`

Pattern with date check (redundancies have been removed):
- `\b[0-9]{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12][0-9]|3[01])-[AFMNGDOHSXZ]-[A-Za-z\d]{5}-\d{3}\d?[A-Za-z]?(-[A-Za-z]{2})?\b$
`

References: 
- https://commons.wikimedia.org/wiki/Commons:VIRIN
- https://web.archive.org/web/20170614121105/http://www.dimoc.mil/quick/virin.html

#### Use & Characteristics
- The VIRIN generator creates VIRINS for testing in a development environment only. This generator does not create VIRINs that are valid or usable in production.
- To use the tool: build it, run it, and enter the number of VIRINs you need created into the console. It will the number of VIRINs entered into the console.
