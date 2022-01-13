Shader "Custom/StencilMaskWithID"
{
    Properties
    {
        _StencilMaskId("Stencil id", Int) = 0
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue" = "Geometry-1"}
        LOD 100

        ColorMask 0
        ZWrite Off
        
        Stencil
        {
            Ref [_StencilMaskId]
            Comp always
            Pass Replace
        }
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                return half4(1,1,1,1);
            }
            ENDCG
        }
    }
}
