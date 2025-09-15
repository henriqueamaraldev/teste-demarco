# Set the working directory
FROM node:22.16.0-alpine AS builder
WORKDIR /app

# Install dependencies
COPY package*.json ./
RUN npm install --ignore-scripts

COPY . .
RUN npx ng build --configuration production

# Use Nginx to serve the application add configuration files and the startup script
FROM nginx:1.24-alpine
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=builder /app/dist/boilerplate-spa/browser /usr/share/nginx/html
COPY start.sh /start.sh
RUN chmod +x /start.sh

# Remove scripts
RUN rm -rf /docker-entrypoint.d/*

EXPOSE 80
CMD ["/start.sh", "nginx", "-g", "daemon off;"]
