// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/J.Michael Shader"
{
	Properties
	{
		// initial texture
		_MainTex("Texture", 2D) = "white" {}
		// secondary texture
		_SecondTex("Second Texture", 2D) = "white" {}
		// inbetweening/tweening factor to affect how the main texture transitions to the second, vice versa
		_Tween("Tween", Range(0, 1)) = 0
	}

		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"PreviewType" = "Plane"
			}

			Pass
			{
				Blend SrcAlpha OneMinusSrcAlpha

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				// vertex to fragment
				struct v2f
				{
					float4 vertex : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				sampler2D _SecondTex;
				float _Tween;

				// allows for fade to and out from the current texture
				float4 frag(v2f i) : SV_Target
				{
					float4 color1 = tex2D(_MainTex, i.uv);
					float4 color2 = tex2D(_SecondTex, i.uv);

					float4 color = lerp(color1, color2, _Tween);

					return color;
				}
				ENDCG
			}
		}
}