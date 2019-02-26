In each ADR file, write these sections:

**Title**: Idiotmatic way of serializing data into csv format.

**Status**: Accepted

**Context**: The client use case is exporting indivual records as comma separated file (.csv)
- Option 1: Manually serialize the data to csv and output it via the ```Response.WriteAsync();```
- Option 2: Create Custom OutputFormatter 
- Option 3: Use existing nuget package.

**Decision**: The decision we have gone with is Option 3. Thereby removing the need to have the output model be aware of any sort of serialization, and allowing us quickest and cleanest delivery time of this feature.

**Consequences**: 
- Idiotmatic way of serializing data into csv format.
- Easily configurable
- Potentially restrictive around DateTime serialization.
- Allows http requests to response "accept" headers.
- Complies with RESTful API.
- Dependent on nuget package - WebApiContrib.Core.Formatter.Csv
- We have to do manual testing around this until we have EndToEnd Tests.