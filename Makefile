.PHONY: run test

TEST_PATH=./tests

test:
	dotnet test ${TEST_PATH}/**/*.csproj
