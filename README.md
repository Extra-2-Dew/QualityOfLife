# Quality of Life

This mod adds various quality of life options to improve your experience with Ittle Dew 2.

Note: In the future, these features will be able to be toggled on/off

## Installation

1. Download the latest version of [ModCore](https://github.com/Extra-2-Dew/ModCore) along with its dependencies.
2. Download the latest release (the zip file) from the [Releases page](https://github.com/Extra-2-Dew/QualityOfLife/releases).
3. Unzip the release and drop it into your Bepinex plugins folder.

## What does this do?

### Splash Skip
Skips the Ludosity splash screen, so you boot straight into Main Menu

###  Run in Background
The game will continue running while it doesn't have focus

### Some Vanilla Bug Fixes
Fixes the following vanilla bugs:

<details>
	<summary>
		<b>Resolution selection list in graphics options might duplicate or miss some resolutions</b>
	</summary>

	In vanilla, you may be missing some resolution selections because of a bug where it could duplicate
	and skip over some selections based on how many total selections your display supports. In one
	known case, this caused 1440p to not be selectable in windowed mode.
</details>

<details>
	<summary>
	<b>Fluffy lake warp override<b>
	</summary>

	In vanilla, if you warp from pause menu after entering Fluffy room A (where Pillow Fort entrance is),
	you'll always respawn at lake (where you do when you start a new game.
</details>

<details>
	<summary>
	<b>Mapman event error</b>
	</summary>

	In vanilla, anytime you load a scene that has a Mapman cutscene event after having seen the first one,
	an exception gets logged to console. This simply removes that exception log to keep the console more tidy.
</details>