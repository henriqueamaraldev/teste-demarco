#!/bin/sh

# Garantir que o diretório de assets exista
mkdir -p /usr/share/nginx/html/assets

# Check if API_URL is defined
if [ -z "$API_URL" ]; then
  echo "API_URL is not set! Exiting."
  exit 1
fi

# Generate the env.js file with the environment variables
cat <<EOF > /usr/share/nginx/html/assets/env.js
window.env = {
  NODE_ENV: '${NODE_ENV}',
  API_URL: '${API_URL}'
};
EOF

# Start Nginx
exec "$@"
