PROJECT := CastBrick.SDK/CastBrick.SDK.csproj
VERSION := $(shell grep '<Version>' CastBrick.SDK/CastBrick.SDK.csproj | sed 's/.*<Version>\(.*\)<\/Version>.*/\1/' | tr -d ' ')

.PHONY: build pack publish release

build:
	dotnet build $(PROJECT) -c Release

pack: build
	dotnet pack $(PROJECT) -c Release --no-build
	@echo "Package: CastBrick.SDK/bin/Release/CastBrick.SDK.$(VERSION).nupkg"

publish: pack
	@if [ -z "$(NUGET_API_KEY)" ]; then \
		echo "Error: NUGET_API_KEY is not set. Run: export NUGET_API_KEY=your_key"; \
		exit 1; \
	fi
	dotnet nuget push CastBrick.SDK/bin/Release/CastBrick.SDK.$(VERSION).nupkg \
		--api-key $(NUGET_API_KEY) \
		--source https://api.nuget.org/v3/index.json

release: publish
	git tag v$(VERSION)
	git push origin v$(VERSION)
	@echo "Released v$(VERSION)"
