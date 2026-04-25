Curso Treinamento Prometheus e Grafana no nextwave(LuisDEV)

### Prometheus
 - O que é
   - Phometheus é uma aplicação open-source de monitoramento e alerta, que coleta e armazena métricas como dados temporais
   - Seu banco de dados é TSDB (times series database), no qual são armazenadas as métricas, record-rules e tudo mais.

### Cardinalidade
 - É a quantidade de valores únicos existente

### Samples
 - Samples formam os dados reais do time series, cada sample consiste de:
   - um valor float64
   - um timestamp em milisegundos

### Tipos de métricas
 - Count: métrica somente cumulativa, podendo ser utilizada para representar quantidades de requests recebidas, erros
 - Gauge: métrica para representar números que podem arbitrariamente subir ou descer, podendo ser utilizada para mensurar valores como temperatura, uso de memória corrente
 - Histogram
 - Summary:  É uma combinação de outros tipos de métricas. Um summary consiste em dois contadores, e, opcionalmente, alguns medidores. São utilizados para rastrear o tamanho dos eventos, geralmente quanto tempo eles levam.

### Histogram
 - É uma métrica que apresenta observações e o contadores em intervalos configuráveis e também fornece a soma de todos os valores observados.
 - Use histogram para calcular quantil
 - Histogram expõe múltiplos time series durante um scrape:
   - contador acomulativo _bucket{le=""}
   - total sum _sum
   - count _count{le="+info"}

### Query (PromQL)
 - Para calcular a média de duração das requisições nos últimos 5min:
   - rate(http_request_duration_seconds_sum[5m]) /
   - rate(http_request_duration_seconds_count[5m])
 - Calcular vetor
   - http_requests_total{}[5m]
 - Função
   - sum by (job) (rate(http_requests_total[5m]))

### Recording Rules
 - É uma boa prática para facilitar a interpretação rápida e também evitar erros ao fazer cálculos incorretos ou sem sentido

### Alerting Rules
 - Permite definir alertas baseado na expressão sobre alertas firing.

 ### Thanos
  - É um “Prometheus” de alta disponibilidade que pode armazenar métricas por muito mais tempo
  - OpenSource
  - Incubado pela CNCF

### Grafana
 - É uma plataforma utilizada para análise e criação de dashboards
 - Suporte a integração com vários tipos de banco de dados
 - OpenSource e SaaS

### Hands On
 - docker build -t awesomesocialmedia-users -f src/AwesomeSocialMedia.Users.API/Dockerfile .
 - docker run --name awesomesocialmedia-usersss -d -p 5001:80 -p 5002:443 awesomesocialmedia-users
 - docker compose up -d --build

