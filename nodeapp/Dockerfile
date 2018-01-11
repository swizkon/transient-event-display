# FROM node:7

# WORKDIR /app
# # VOLUME c:/env

# COPY package.json /app
# RUN npm install
# COPY . /app

# CMD node index.js


FROM iojs:onbuild

COPY ./program.js ./program.js
COPY ./package.json ./package.json

# COPY ./program.sh ./program.sh
# RUN  chmod +x ./program.sh

EXPOSE 3000

ENTRYPOINT ["node", "program"]
# ENTRYPOINT ["./program.sh"]