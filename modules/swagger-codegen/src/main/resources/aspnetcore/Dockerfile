FROM microsoft/dotnet:2.1.500-sdk AS base

WORKDIR /app

# Set up world readable folders for dotnet + package caching
# This allows us to run as non-root
RUN mkdir -m 777 /.dotnet
RUN mkdir -m 777 /.nuget


FROM base as development
# we don't need to do anything else here, since we'll be using
# a volume

CMD bash


# TODO: we need to hook this up into the makefile for our OSX people.
FROM development as runtime
# OSX isn't great with volumes, so we'll also package it together for use

# Add project files
COPY HomesEngland/*.csproj ./HomesEngland/
COPY WebApi/*.csproj ./WebApi/

# As WebApi references HomesEngland, we only need to
# restore WebApi
RUN dotnet restore WebApi

# Add the rest after we've built
ADD . ./

EXPOSE 5000

CMD dotnet run --project WebApi
