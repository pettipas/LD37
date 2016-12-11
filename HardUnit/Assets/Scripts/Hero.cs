using UnityEngine;
using System.Collections;
using InControl;

public class Hero : MonoBehaviour {


    public static Hero Instance;

    public Vector3 resultant;

    public Body body;
    public Vector3 direction;
    Vector3 pushDir;
    public float angleOfAttack;

    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected CharacterController ctrl;


    [SerializeField]
    public GunsOut gunsOut;


    [SerializeField]
    protected Walk walk;
    [SerializeField]
    protected Slide slide;
    [SerializeField]
    protected Movement move;
    [SerializeField]
    protected TakeDamage damage;
    [SerializeField]
    protected Invulnerability invulnerability;
    [SerializeField]
    protected MaterialFlasher flasher;
    [SerializeField]
    protected SphereCollider characterCollider;

    public Vector3 PushDir {
        get {
            return pushDir;
        }set {
            pushDir = new Vector3(value.x,0,value.y).normalized;
        }
    }

    public CharacterController Ctrl{
        get{
            return ctrl;
        }
    }

    string WalkAnimation{
        get{
            return "hero_walk";
        }
    }

    string RestAnimation{
        get{
            return "hero_rest";
        }
    }

    string SlideAnimation{
        get{
            return "hero_slide";
        }
    }

    string TakeDamageAnimation {
        get {
            return "hero_takedamage";
        }
    }

    string GunsOutAnimation {
        get {
            return "hero_show_weapon_torso";
        }
    }

    string GunsOutAnimationRest {
        get {
            return "hero_show_weapon_torso_rest";
        }
    }

    public void ForceIntoTakeDamage(Transform other) {

        if (Invulnerable) {
            return;
        }

        if (other && TakingDamage) {
            damage.Renew((transform.position-other.position).normalized);
        } else if (other && !TakingDamage) {
            PushDir = (transform.position - other.position).normalized;
            SetMode(Mode.Damaged);
            gunsOut.Pause();
        }
    }

    public void FaceDirectionOfMotion(){
        if(direction != Vector3.zero){
            body.transform.forward = direction;
        }
    }

    public bool AnimateGunsOut() {
        if (!animator.IsNamedStateActive(GunsOutAnimation)) {
            animator.Play(GunsOutAnimation, 0, 0);
            return true;
        }
        return false;
    }

    public bool AnimateGunsOutRest() {
        if (!animator.IsNamedStateActive(GunsOutAnimationRest)) {
            animator.Play(GunsOutAnimationRest, 0, 0);
            return true;
        }
        return false;
    }

    public bool AnimateWalking(){
        if(!animator.IsNamedStateActive(WalkAnimation)){
            animator.Play(WalkAnimation,0,0);
            return true;
        }
        return false;
    }

    public bool AnimateSliding(){
        if(!animator.IsNamedStateActive(SlideAnimation)){
            animator.Play(SlideAnimation, 0,0);
            return true;
        }
        return false;
    }

    public bool AnimateResting(){
        if(!animator.IsNamedStateActive(RestAnimation)){
            animator.Play(RestAnimation,0,0);
            return true;
        }
        return false;
    }

    public bool AnimateTakeDamage() {
        if (!animator.IsNamedStateActive(TakeDamageAnimation)) {
            animator.Play(TakeDamageAnimation, 0, 0);
            return true;
        }
        return false;
    }

    public Animator Animator{
        get{
            return animator;
        }
    }

    public bool GunsOut {
        get {
            return gunsOut.enabled;
        }
    }

    public bool Walking{
        get{
            return walk.enabled;
        }
    }

    public bool StandingStill{
        get{
            return Ctrl.velocity == Vector3.zero;
        }
    }

    public bool Slideing{
        get{
            return slide.enabled;
        }
    }

    public bool TakingDamage {
        get {
            return damage.enabled;
        }
    }

    public bool Invulnerable{
        get{
            return invulnerability.enabled;
        }
    }

    public MaterialFlasher Flasher{
        get{
            return flasher;
        }
    }

    public SphereCollider Collider {
        get {
            return characterCollider;
        }
    }

    [ContextMenu("SetUp")]
    public void SetUp() {
        gameObject.AddIfNull<CharacterController>();
        gameObject.AddIfNull<Walk>();
        gameObject.AddIfNull<Slide>();
        gameObject.AddIfNull<Movement>();
        gameObject.AddIfNull<Invulnerability>();
        gameObject.AddIfNull<Body>();
        gameObject.AddIfNull<TakeDamage>();
        gameObject.AddIfNull<MaterialFlasher>();
        gameObject.AddIfNull<SphereCollider>();
        gameObject.AddIfNull<GunsOut>();
    }

    public void Reset(){
        walk.SafeDisable();
        slide.SafeDisable();
        move.SafeDisable();
        damage.SafeDisable();
        invulnerability.SafeDisable();
        flasher.SafeDisable();
        gunsOut.SafeDisable();
    }

    public void SetMode(Mode m){
        
        if(m == Mode.Invulnerable) {
            invulnerability.SafeEnable();
        }

        if(m == Mode.Vulnerable){
            invulnerability.SafeDisable();
        }

        if(m == Mode.Walk) {
            slide.SafeDisable();
            damage.SafeDisable();
            walk.SafeEnable();
            move.SafeEnable();
        }

        if(m == Mode.Slide){
            slide.SafeEnable();
            walk.SafeDisable();
            move.SafeDisable();
            damage.SafeDisable();
        }

        if (m == Mode.Damaged) {
            slide.SafeDisable();
            walk.SafeDisable();
            move.SafeDisable();
            damage.SafeEnable();
        }

    }

    public void Awake(){
        direction = Vector3.zero;
        ctrl = GetComponent<CharacterController>();
        walk = GetComponent<Walk>();
        slide = GetComponent<Slide>();
        move = GetComponent<Movement>();
        invulnerability = GetComponent<Invulnerability>();
        body = GetComponentInChildren<Body>();
        damage = GetComponentInChildren<TakeDamage>();
        flasher = GetComponent<MaterialFlasher>();
        gunsOut = GetComponent<GunsOut>();
        characterCollider = GetComponent<SphereCollider>();
        Reset();

        SetMode(Mode.Walk);
        SetMode(Mode.Vulnerable);
        Instance = this;
        name = "hardunit";
    }
}

public enum Mode{
    Walk,
    Slide,
    Damaged,
    Invulnerable,
    Vulnerable,
    Guns
}