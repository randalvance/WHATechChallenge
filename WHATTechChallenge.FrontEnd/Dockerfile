FROM nginx

WORKDIR /usr/share/nginx/html

COPY /dist .

COPY start.sh /start.sh

CMD ["sh", "/start.sh"]