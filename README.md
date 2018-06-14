# Curl Builder

This library can render the curl command line (cmd or bash) from a HttpContext

# Useful
It is used to help debugging, log and trace incoming request

# Sample
The sample project **aspnet-core-mvc** print to output visualstudio window when income a request
```
curl -XGET "-H Connection: Keep-Alive" "-H Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8" "-H Accept-Encoding: gzip, deflate, br" "-H Accept-Language: pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,es;q=0.6,ja;q=0.5" "-H Cookie: _ga=GA1.1.398854594.1528135872" "-H Host: localhost:44306" "-H User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.62 Safari/537.36" "-H upgrade-insecure-requests: 1" "-H MS-ASPNETCORE-TOKEN: 21ec59aa-82b1-4f11-940a-1406ddba7f84" "-H X-Original-Proto: http" "-H X-Original-For: 127.0.0.1:51218" https://localhost:44306/
```

