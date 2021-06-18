Shader "Dapasa/Two Sided" {
	Properties {
		_Color("Color", Color) = (1,1,1,1)
		[NoScaleOffset] _MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		[Gamma] _Metallic("Metallic", Range(0,1)) = 0.0
		[NoScaleOffset] _BumpMap("Normal Map", 2D) = "bump" {}
		[Enum(Flip,0,Invert,1)] _BumpDrawBackMode("Normal Draw Back Mode", Float) = 0
	}

	SubShader {
		Tags { "RenderType" = "Opaque" }
		Cull Off
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard fullforwardshadows

		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;

		struct Input {
			float2 uv_MainTex;
			fixed facing : VFACE;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		bool _BumpDrawBackMode;

		void surf(Input IN, inout SurfaceOutputStandard o) {
			
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));

			if (IN.facing < 0.5)
			{
				if (_BumpDrawBackMode)
					o.Normal *= -1.0;
				else
					o.Normal.z *= -1.0;
			}
		}
		ENDCG
	}
	FallBack "Diffuse"
}
