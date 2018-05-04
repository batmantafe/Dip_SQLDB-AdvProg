﻿// Location of Shader in Material Inspector
Shader "Duane's Shaders/Object Shader 2" {
// What does this Object Shader do?
// 1. Red value of Texture can be adjusted using "Red Value" range slider.
// 2. 
// 3. 
	
	/*******************************************************************************************/
	// Used by Unity3D to give access from the inspector to the hidden variables within a shader.
	// These variables still need to be defined in the SubShader section.
	Properties{

		_Tex("Texture", 2D) = "white" {}

		_Intensity("Red Value", Range(-1,7.5)) = 1

		_Cube("Cube", CUBE) = "" {}
	}
		/*******************************************************/

		/*******************************************************/
			// Processing
		SubShader{

		Pass{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM // Start High-Level Shader Language

		// Shader Type ("surface"), Function Name ("surfFunction"), Lighting Type ("Lambert")
		// Shader Types: surface, vert (runs on each vertex of the 3D model), frag (runs on each/every pixel on object onscreen)
		// Lighting Types: Lambert, SimpleLambert, WrapLambert, Ramp, SimpleSpecular

#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"


	// Input data from Model's mesh (e.g. vertices, normals, UVs)
	struct Input {
		float2 uv :TEXCOORD0;
		float4 vertex : POSITION;
	};

	struct v2f {
		float4 position : POSITION;
		float2 uv : TEXCOORD0;
	};

	// To access Properties created (type, name)
	sampler2D _Tex;
	half _Intensity;

	samplerCUBE _Cube;

	// vertex2fragment Function vert, taking in Input struct data
	v2f vert(Input IN) {

		v2f o;

		// get Model/View/Projection
		o.position = mul(UNITY_MATRIX_MVP, IN.vertex);

		// output UV is uv from Input struct
		o.uv = IN.uv;

		return o;
	}

	// fragment Function, taking in v2f data above
	fixed4 frag(v2f IN) : SV_Target{

		// variable texColour to be returned = Texture
		float4 texColour = tex2D(_Tex, IN.uv);

		// Red value of Texture = Red value of Texture * Intensity Range slider
		texColour.r = texColour.r * _Intensity; //* sin(_Time.y));

		// output texColour result from Function
		return texColour;
	}

		// Shader Function
		// Takes IN the Input struct, inout SurfaceOutput struct as "o" (the Struct has access to variables that can be manipulated, e.g. Albedo)
		/*void surfFunction(Input IN, inout SurfaceOutput o) {
			// Apply texture to Albedo.
			// "tex2D" is built-in function
			o.Albedo = tex2D(_Tex, IN.uv_Tex).rgb;

			// Only emit Green
			// o.Emission = (tex2D(_Tex, IN.uv_Tex) * _GreenRange).g;

			o.Emission = texCUBE(_Cube, IN.worldRefl).rgb;
		}*/

		ENDCG // End High-Level Shader Language
	}

	}
		/************************************************************************/

			// For inferiour GPUs
		FallBack "Diffuse"
}