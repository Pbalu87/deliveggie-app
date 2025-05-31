# Stage 1: Build the Angular app
FROM node:18 AS build

WORKDIR /app
COPY package*.json ./
RUN npm install
RUN npm install -g @angular/cli

COPY . .
RUN npm run build:prod

# Stage 2: Serve the Angular app with Nginx
FROM nginx:alpine

# Remove default nginx static assets
RUN rm -rf /usr/share/nginx/html/deliveggie

# Copy build output to Nginx HTML folder
COPY --from=build /app/dist/deliveggie /usr/share/nginx/html/

# Copy custom nginx config if needed
# COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
