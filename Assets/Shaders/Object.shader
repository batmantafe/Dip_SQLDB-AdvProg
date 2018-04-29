// Location of Shader in Material Inspector
Shader "Duane's Shaders/Object Shader"
{
	// Visible variables in Inspector
	Properties
	{
		_Colour("Colour", Color) = (1,1,1,1)
	}

	// Processing
	SubShader
	{
	CGPROGRAM // Start High-Level Shader Language
	
	// Type of Shader ("surface"), Name of Shader ("surf"), Type of Lighting ("Lambert")
	#pragma surface surf Lambert
	
	// Input data from Model's mesh (e.g. vertices, normals, UVs)
	struct Input
	{
		float2 uvMainTex;
	};

	// To access Properties created (type, name)
	fixed4 _Colour;

	// Shader Function
	// Takes IN the Input struct, inout SurfaceOutput struct as "o"
	void surf(Input IN, inout SurfaceOutput o)
	{
		// o's Albedo matches RGB on _Colour property value
		o.Albedo = _Colour.rgb;
	}

	ENDCG // End High-Level Shader Language
	}

		// For inferiour GPUs
		FallBack "Diffuse"
}
