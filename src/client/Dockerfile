FROM node:fermium-buster as node
WORKDIR /app
EXPOSE 80

COPY src/client/ .

RUN npm install
RUN npm run build

FROM nginx:alpine
COPY --from=node /app/dist/client /usr/share/nginx/html
