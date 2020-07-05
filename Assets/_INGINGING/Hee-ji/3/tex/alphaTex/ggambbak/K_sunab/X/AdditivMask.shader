Shader "Custom/AdditivMask" {
	Properties{
		_TintColor("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("Particle Texture", 2D) = "white" {}
	_AlphaMap("Additional Alpha Map (Greyscale)", 2D) = "white" {}
	}

		SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Blend SrcAlpha One
		AlphaTest Greater .01
		ColorMask RGB
		Cull Off Lighting Off ZWrite Off Fog{ Color(0,0,0,0) }
		BindChannels{
		Bind "Color", color
		Bind "Vertex", vertex
		Bind "TexCoord", texcoord
	}
		LOD 200

		CGPROGRAM
#pragma surface surf Lambert

		sampler2D _MainTex;
	sampler2D _AlphaMap;
	fixed4 _TintColor;

	struct Input {
		float2 uv_MainTex;
		float2 uv_AlphaMap;
	};

	void surf(Input IN, inout SurfaceOutput o) {
		half4 c = tex2D(_MainTex, IN.uv_MainTex) * _TintColor;
		o.Albedo = c.rgb;
		o.Alpha = c.a * tex2D(_AlphaMap, IN.uv_AlphaMap).r;
	}
	ENDCG
	}
		FallBack "Diffuse"
}