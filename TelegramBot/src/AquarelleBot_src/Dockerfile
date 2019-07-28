FROM microsoft/dotnet:1.0.4-sdk

# Copy files to app directory 
COPY . /app

# Set the Working Directory
WORKDIR /app

# Restore NuGet packages 
RUN ["dotnet", "restore"] 

# Build the app 
RUN ["dotnet", "build"]


# Copy the app
COPY . /app

# Configure the listening port to 8016
ENV ASPNETCORE_URLS http://*:8016
EXPOSE 8016


# Start the app
#ENTRYPOINT dotnet DanceBot.dll

# Run the app 
ENTRYPOINT ["dotnet", "run"]


