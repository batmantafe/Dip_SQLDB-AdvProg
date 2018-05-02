// Location of Shader in Material Inspector
Shader "Duane's Shaders/Object Shader" {
	/*******************************************************************************************/
	// Used by Unity3D to give access from the inspector to the hidden variables within a shader.
	// These variables still need to be defined in the SubShader section.
	Properties{
		_Colour("Colour", Color) = (50,1,1,1)

		_Tex("Texture", 2D) = "white" {}

		_GreenRange("Green Range", Range(-2,1)) = 0

		_Cube("Cube", CUBE) = "" {}
	}
		/*******************************************************/

		/*******************************************************/
			// Processing
		SubShader{
		Tags{ "RenderType" = "Opaque" }

		CGPROGRAM // Start High-Level Shader Language

		// Shader Type ("surface"), Function Name ("surfFunction"), Lighting Type ("Lambert")
		// Shader Types: surface, vert (runs on each vertex of the 3D model), frag (runs on each/every pixel on object onscreen)
		// Lighting Types: Lambert, SimpleLambert, WrapLambert, Ramp, SimpleSpecular
	
	#pragma surface surfFunction Lambert


	// Input data from Model's mesh (e.g. vertices, normals, UVs)
	struct Input {
		float2 uv_Tex;
		float3 worldRefl;
	};

	// To access Properties created (type, name)
	sampler2D _Tex;
	half _GreenRange;
	samplerCUBE _Cube;

	// Shader Function
	// Takes IN the Input struct, inout SurfaceOutput struct as "o" (the Struct has access to variables that can be manipulated, e.g. Albedo)
	void surfFunction(Input IN, inout SurfaceOutput o) {
		// Apply texture to Albedo.
		// "tex2D" is built-in function
		o.Albedo = tex2D(_Tex, IN.uv_Tex).rgb;

		// Only emit Green
		// o.Emission = (tex2D(_Tex, IN.uv_Tex) * _GreenRange).g;

		o.Emission = texCUBE(_Cube, IN.worldRefl).rgb;
	}

	ENDCG // End High-Level Shader Language
	}

		/************************************************************************/

			// For inferiour GPUs
		FallBack "Diffuse"
}