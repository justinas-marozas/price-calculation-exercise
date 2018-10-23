.PHONY: run test

DEFAULT_PROJECT=./src/PriceCalculation.CLI/PriceCalculation.CLI.csproj
TEST_PATH=./tests

run:
	dotnet run --project ${DEFAULT_PROJECT}

test:
	dotnet test ${TEST_PATH}/**/*.csproj
