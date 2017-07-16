/bin/sed -i "s|API_BASE_URL|${API_BASE_URL}|" /usr/share/nginx/html/api_urls.js

nginx -g 'daemon off;'