Shader "Custom/ShinOutline"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)

        _OutlineTex("Outline Texture", 2D) = "white" {}
        _OutlineColor("Outline color", Color) = (1,1,1,1)
        _OutlineWidth("Outline Width", Range(1.0, 10.0)) = 1.0
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
        }
        // Pass for outline
        Pass 
        {
            Name "OUTLINE"
            ZWrite Off
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
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _OutlineColor;
            sampler2D _OutlineTex;
            float _OutlineWidth;

            v2f vert(appdata IN) 
            {
                IN.vertex.xyz *= _OutlineWidth;
                v2f OUT;
                OUT.pos = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                float4 texcolor = tex2D(_OutlineTex, IN.uv);
                return texcolor *  _OutlineColor;
            }

            ENDCG
        }

        // Pass for main texture
        Pass
        {
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
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            float4 _Color;
            sampler2D _MainTex;

            v2f vert(appdata IN) 
            {
                v2f OUT;
                OUT.pos = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;

                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                float4 texcolor = tex2D(_MainTex, IN.uv);
                return texcolor *  _Color;
            }

            ENDCG
        }
    }
}
