// Upgrade NOTE: commented out 'float4 unity_DynamicLightmapST', a built-in variable
// Upgrade NOTE: commented out 'float4 unity_LightmapST', a built-in variable

// Shader created with Shader Forge v1.03 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.03;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:5212,x:32719,y:32712,varname:node_5212,prsc:2|emission-8524-OUT,clip-2698-OUT;n:type:ShaderForge.SFN_TexCoord,id:4005,x:30220,y:33022,varname:node_4005,prsc:2,uv:0;n:type:ShaderForge.SFN_Lerp,id:8524,x:32226,y:32615,varname:node_8524,prsc:2|A-4055-RGB,B-368-RGB,T-7524-OUT;n:type:ShaderForge.SFN_Color,id:368,x:31789,y:32235,ptovrint:False,ptlb:Full_Life,ptin:_Full_Life,varname:node_368,prsc:2,glob:False,c1:0,c2:1,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:4055,x:31989,y:32148,ptovrint:False,ptlb:No_Life,ptin:_No_Life,varname:node_4055,prsc:2,glob:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Slider,id:7524,x:31268,y:32487,ptovrint:False,ptlb:Health,ptin:_Health,varname:node_7524,prsc:2,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:1947,x:30439,y:33019,varname:node_1947,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4005-UVOUT;n:type:ShaderForge.SFN_Length,id:4048,x:30938,y:33101,varname:node_4048,prsc:2|IN-1947-OUT;n:type:ShaderForge.SFN_Floor,id:3123,x:31518,y:33146,varname:node_3123,prsc:2|IN-4048-OUT;n:type:ShaderForge.SFN_OneMinus,id:1848,x:31723,y:33146,varname:node_1848,prsc:2|IN-3123-OUT;n:type:ShaderForge.SFN_Vector1,id:9628,x:31468,y:32892,varname:node_9628,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Add,id:1633,x:31624,y:32915,varname:node_1633,prsc:2|A-9628-OUT,B-4048-OUT;n:type:ShaderForge.SFN_Floor,id:2196,x:31839,y:32973,varname:node_2196,prsc:2|IN-1633-OUT;n:type:ShaderForge.SFN_Multiply,id:2698,x:32118,y:32943,varname:node_2698,prsc:2|A-312-OUT,B-2196-OUT,C-1848-OUT;n:type:ShaderForge.SFN_ArcTan2,id:4310,x:30923,y:32885,varname:node_4310,prsc:2|A-1130-G,B-1130-R;n:type:ShaderForge.SFN_ComponentMask,id:1130,x:30729,y:32872,varname:node_1130,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1947-OUT;n:type:ShaderForge.SFN_Ceil,id:312,x:31620,y:32738,varname:node_312,prsc:2|IN-1094-OUT;n:type:ShaderForge.SFN_Subtract,id:1094,x:31468,y:32702,varname:node_1094,prsc:2|A-7524-OUT,B-5606-OUT;n:type:ShaderForge.SFN_RemapRange,id:5606,x:31141,y:32825,varname:node_5606,prsc:2,frmn:-3.14,frmx:3.14,tomn:0,tomx:1|IN-4310-OUT;proporder:368-4055-7524;pass:END;sub:END;*/

Shader "Shader Forge/HealthBarShader" {
    Properties {
        _Full_Life ("Full_Life", Color) = (0,1,0,1)
        _No_Life ("No_Life", Color) = (1,0,0,1)
        _Health ("Health", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float4 _Full_Life;
            uniform float4 _No_Life;
            uniform float _Health;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
                UNITY_FOG_COORDS(2)
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                o.screenPos = o.pos;
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float2 node_1947 = (i.uv0*2.0+-1.0);
                float2 node_1130 = node_1947.rg;
                float node_4310 = atan2(node_1130.g,node_1130.r);
                float node_4048 = length(node_1947);
                clip( BinaryDither3x3((ceil((_Health-(node_4310*0.1592357+0.5)))*floor((0.2+node_4048))*(1.0 - floor(node_4048))) - 1.5, sceneUVs) );
////// Lighting:
////// Emissive:
                float3 emissive = lerp(_No_Life.rgb,_Full_Life.rgb,_Health);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float _Health;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                float4 screenPos : TEXCOORD6;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD7;
                #else
                    float3 shLight : TEXCOORD7;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float2 node_1947 = (i.uv0*2.0+-1.0);
                float2 node_1130 = node_1947.rg;
                float node_4310 = atan2(node_1130.g,node_1130.r);
                float node_4048 = length(node_1947);
                clip( BinaryDither3x3((ceil((_Health-(node_4310*0.1592357+0.5)))*floor((0.2+node_4048))*(1.0 - floor(node_4048))) - 1.5, sceneUVs) );
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 3x3 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither3x3( float value, float2 sceneUVs ) {
                float3x3 mtx = float3x3(
                    float3( 3,  7,  4 )/10.0,
                    float3( 6,  1,  9 )/10.0,
                    float3( 2,  8,  5 )/10.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,3);
                int ySmp = fmod(px.y,3);
                float3 xVec = 1-saturate(abs(float3(0,1,2) - xSmp));
                float3 yVec = 1-saturate(abs(float3(0,1,2) - ySmp));
                float3 pxMult = float3( dot(mtx[0],yVec), dot(mtx[1],yVec), dot(mtx[2],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            // float4 unity_LightmapST;
            #ifdef DYNAMICLIGHTMAP_ON
                // float4 unity_DynamicLightmapST;
            #endif
            uniform float _Health;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
                #ifndef LIGHTMAP_OFF
                    float4 uvLM : TEXCOORD3;
                #else
                    float3 shLight : TEXCOORD3;
                #endif
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float2 node_1947 = (i.uv0*2.0+-1.0);
                float2 node_1130 = node_1947.rg;
                float node_4310 = atan2(node_1130.g,node_1130.r);
                float node_4048 = length(node_1947);
                clip( BinaryDither3x3((ceil((_Health-(node_4310*0.1592357+0.5)))*floor((0.2+node_4048))*(1.0 - floor(node_4048))) - 1.5, sceneUVs) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
