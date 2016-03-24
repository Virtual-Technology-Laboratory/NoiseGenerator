# NoiseGenerator
This package utilizes Perlin methods to create a hash based noise texture.

NoiseGenerator//REQUIREMENTS:
 -Unity5.3.xxx or later

NoiseGenerator//SETUP:
 -Start the provided Unity scene and play with the settings on the Quad object in the heirarchy.
 -Filter Mode describes the filter mode of the texture as displayed in Unity
 -Resolution describes the square resolution of the texture
 -Frequency describes how often the patterns are repeated in the texture (larger is denser)
 -Octaves: describes how many noise passes are made
 -Lacunarity: describes the relative scale of the passes (shrink by pass/X)
 -Persistence: describes how the Octave passes are blended (higher is more blending)
 -Dimensions: describes how many dimensions are factored into the noise (X,Y,Z; 1D = X)
 -Type: describes either Value (transform to value) or Perlin (transform to gradient)
 -Coloring: describes the color range to be applied to the texture (Color.white * gradient@noise.value)
 -Save Texture will output the texture to a .PNG file in /Assets/Textures/Saved/

NoiseGenerator//NOTES:
 -Based on the tutorial provided by Catlike Coding at http://catlikecoding.com/unity/tutorials/noise/

-------------------------------------------
This software is licensed under the BSD 3-Clause License

Copyright (c) 2015, Jacob Cooper (coop3683@outlook.com)
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, 
are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this 
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, 
   this list of conditions and the following disclaimer in the documentation 
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors 
   may be used to endorse or promote products derived from this software without 
   specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR 
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES 
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (
INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
