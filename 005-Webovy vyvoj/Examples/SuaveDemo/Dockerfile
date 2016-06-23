FROM        frolvlad/alpine-mono
MAINTAINER  Roman Provaznik <dzoukr@dzoukr.cz>

ADD ./SuaveDemo/bin/Debug/ app/
EXPOSE 8083
WORKDIR ./app/
ENTRYPOINT ["mono", "SuaveDemo.exe"]