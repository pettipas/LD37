Shader "VertexColors" {
    Properties {
        _Color ("Color", Color) = (1.00, 1.00, 1.00, 1.00) // white
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Lambert
       
        fixed4 _Color;
 
        struct Input {
            float2 uv_MainTex;
            float4 color : COLOR;
        };
 
        void surf (Input IN, inout SurfaceOutput o) {
            o.Albedo = IN.color.rgb * _Color.rgb;
            o.Alpha = IN.color.a * _Color.a;
        }
        ENDCG
    } 
    FallBack "Diffuse"
}