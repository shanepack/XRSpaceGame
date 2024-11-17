Shader "Unlit/FresnelGlow"
{
    Properties
    {
        _Color ("Base Color", Color) = (1,1,1,1)
        _GlowColor ("Glow Color", Color) = (0,0.5,1,1)
        _GlowIntensity ("Glow Intensity", Range(0, 10)) = 1
        _FresnelPower ("Fresnel Power", Range(1, 5)) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // Properties
            float4 _Color;
            float4 _GlowColor;
            float _GlowIntensity;
            float _FresnelPower;

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 viewDir : TEXCOORD0;
                float3 normal : TEXCOORD1;
            };

            // Vertex Shader
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.viewDir = normalize(_WorldSpaceCameraPos - worldPos);
                o.normal = normalize(mul((float3x3)unity_ObjectToWorld, v.normal));
                return o;
            }

            // Fragment Shader
            float4 frag (v2f i) : SV_Target
            {
                // Fresnel effect calculation
                float fresnel = pow(1.0 - saturate(dot(i.normal, i.viewDir)), _FresnelPower);

                // Base color
                float4 baseColor = _Color;

                // Add Fresnel glow to emission
                float4 glow = fresnel * _GlowColor * _GlowIntensity;

                return baseColor + glow;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
